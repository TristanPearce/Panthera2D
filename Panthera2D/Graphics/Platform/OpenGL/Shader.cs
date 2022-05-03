using System;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using static Panthera2D.Native.DLL;
using static Panthera2D.Native.OpenGL;

namespace Panthera2D.Graphics
{
    public class Shader : IDisposable
    {
        private uint _id;
        public uint Id => _id;

        public Shader(string vertexShaderText, string fragmentShaderText)
        {
            uint vertexShaderId = csglShader(vertexShaderText, GL_VERTEX_SHADER);
            uint fragmentShaderId = csglShader(fragmentShaderText, GL_FRAGMENT_SHADER);

            _id = csglShaderProgram(vertexShaderId, fragmentShaderId);

            //shaders are deleted by csgl
        }

        public void Use()
        {
            glUseProgram(_id);
        }

        public void Set1i(string name, int val)
        {
            int location = glGetUniformLocation(_id, name);
            glUniform1i(location, val);
        }

        public void Set4f(string name, float x, float y, float z, float w)
        {
            int location = glGetUniformLocation(_id, name);
            glUniform4f(location, x, y, z, w);
        }

        public void Set3f(string name, float x, float y, float z)
        {
            int location = glGetUniformLocation(_id, name);
            glUniform3f(location, x, y, z);
        }

        public void SetMat4(string name, Matrix4x4 mat)
        {
            int location = glGetUniformLocation(_id, name);
            glUniformMatrix4fv(location, 1, GL_FALSE, ref mat.M11);
        }

        public void Dispose()
        {
            glDeleteProgram(_id);
        }

        #region CSGL Shader
        public static uint csglShader(IntPtr shaderSource, uint type, int length = 0)
        {
            #region Compile
            uint shader = glCreateShader(type);

            glShaderSource(shader, 1, ref shaderSource, ref length);
            glCompileShader(shader);
            #endregion

            #region Assert
            int success = 0;
            glGetShaderiv(shader, GL_COMPILE_STATUS, ref success);

            if (success == 0)
            {
                IntPtr log = Marshal.AllocHGlobal(512);
                glGetShaderInfoLog(shader, 512, ref length, log);

                byte[] buffer = new byte[length];
                Marshal.Copy(log, buffer, 0, length);
                Marshal.FreeHGlobal(log);

                throw new Exception(Encoding.ASCII.GetString(buffer));
            }
            #endregion

            return shader;
        }

        public static uint csglShader(byte[] shaderSource, uint type)
        {
            IntPtr ptrSource = Marshal.AllocHGlobal(shaderSource.Length);
            Marshal.Copy(shaderSource, 0, ptrSource, shaderSource.Length);

            uint shader = csglShader(ptrSource, type, shaderSource.Length);

            Marshal.FreeHGlobal(ptrSource);

            return shader;
        }

        public static uint csglShader(string shaderSource, uint type)
        {
            return csglShader(Encoding.ASCII.GetBytes(shaderSource), type);
        }

        public static uint csglShaderFile(string filename, uint type, bool ascii = true)
        {
            if (ascii)
                return csglShader(File.ReadAllBytes(filename), type);
            else
                return csglShader(File.ReadAllText(filename), type);
        }

        public static uint csglShaderProgram(params uint[] shaders)
        {
            #region Link
            uint shaderProgram = glCreateProgram();

            foreach (uint shader in shaders)
                glAttachShader(shaderProgram, shader);

            glLinkProgram(shaderProgram);
            #endregion

            #region Assert
            int success = 0;
            glGetProgramiv(shaderProgram, GL_LINK_STATUS, ref success);

            if (success == 0)
            {
                int length = 0;
                IntPtr log = Marshal.AllocHGlobal(512);
                glGetProgramInfoLog(shaderProgram, 512, ref length, log);

                byte[] buffer = new byte[length];
                Marshal.Copy(log, buffer, 0, length);
                Marshal.FreeHGlobal(log);

                throw new Exception(System.Text.Encoding.ASCII.GetString(buffer));
            }
            #endregion

            #region Clean
            foreach (uint shader in shaders)
                glDeleteShader(shader);
            #endregion

            return shaderProgram;
        }
        #endregion
    }
}
