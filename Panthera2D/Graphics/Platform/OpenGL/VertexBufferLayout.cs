using System;
using System.Collections;
using System.Collections.Generic;

using static Panthera2D.Native.OpenGL;

namespace Panthera2D.Graphics
{
    /// <summary>
    /// Represents the vertex attribute layout
    /// </summary>
    public class VertexBufferLayout : IEnumerable
    {
        private List<VertexBufferLayoutItem> _layoutItems;

        public VertexBufferLayout()
        {
            _layoutItems = new List<VertexBufferLayoutItem>();
        }

        /// <summary>
        /// Apply the layout to OpenGL
        /// </summary>
        public void Bind()
        {

            int totalSize = 0;
            for (uint i = 0; i < _layoutItems.Count; i++)
            {
                VertexBufferLayoutItem item = _layoutItems[(int)i];
                totalSize += item.Count * item.Size;
            }

            IntPtr offset = new IntPtr();
            for (uint i = 0; i < _layoutItems.Count; i++)
            {
                VertexBufferLayoutItem item = _layoutItems[(int)i];

                uint OpenGLType = BufferableTypeToOpenGLType(item.Type);
                byte OpenGlNorm = item.Normalised ? GL_TRUE : GL_FALSE;
                glVertexAttribPointer(
                    i, //index (location)
                    item.Count, //count (number of items)
                    OpenGLType, // Type
                    OpenGlNorm, // Normalised
                    totalSize,  //size in bytes
                    offset); //offset pointer

                offset += item.Count * item.Size;
            }
        }

        /// <summary>
        /// Enable all Attribute Arrays. This is probably a bad implementation because it assumes that it posesses attributes 0 to whatever.
        /// </summary>
        public void Enable()
        {
            for (uint i = 0; i < _layoutItems.Count; i++)
            {
                glEnableVertexAttribArray(i);
            }
        }

        //enable a specific attriute array
        public void Enable(uint index)
        {
            glEnableVertexAttribArray(index);
        }

        /// <summary>
        /// Push an attibute onto the layout
        /// </summary>
        /// <typeparam name="T">The type of attribute to push</typeparam>
        /// <param name="count">How many of T</param>
        /// <param name="normalised">Should the value be normilised?</param>
        /// <remarks>
        /// <list type="">
        /// <listheader>Supported Types</listheader>
        /// <item>float (Single)</item>
        /// <item>byte (Byte)</item>
        /// </list>
        /// </remarks>
        public void Push<T>(int count, bool normalised = false)
        {
            if (typeof(T) == typeof(Single))
                Push(typeof(Single), sizeof(Single), count, normalised);
            else if (typeof(T) == typeof(Byte))
                Push(typeof(Byte), sizeof(Byte), count, normalised);
            else
                throw new ArgumentException($"The type {typeof(T).Name} is not a recognised bufferable type");
        }

        /// <summary>
        /// Used to create new VertexBufferLayoutItem and append it to the list
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sizeInBytes"></param>
        /// <param name="count"></param>
        /// <param name="normalised"></param>
        private void Push(Type type, int sizeInBytes, int count, bool normalised)
        {
            VertexBufferLayoutItem item = new VertexBufferLayoutItem();
            item.Count = count;
            item.Type = type;
            item.Normalised = normalised;
            item.Size = sizeInBytes;

            _layoutItems.Add(item);
        }

        private uint BufferableTypeToOpenGLType(Type type)
        {
            if (type == typeof(Single))
                return GL_FLOAT;
            if (type == typeof(Byte))
                return GL_UNSIGNED_BYTE;
            if (type == typeof(Double))
                return GL_DOUBLE;
            else
                throw new ArgumentException($"The type {type.Name} can not be converted " +
                    $"to a GL Type, or this conversion has not been implemented.");

        }

        public IEnumerator GetEnumerator()
        {
            return _layoutItems.GetEnumerator();
        }

        /// <summary>
        /// Represents one attribute item.
        /// <para>
        /// One of these maps to one call to glVertexAttribPointer()
        /// </para>
        /// </summary>
        /// 
        private struct VertexBufferLayoutItem
        {
            public int Count;
            public Type Type;
            public bool Normalised;
            public int Size; // of a single entry (total size / Count)

            public override string ToString()
            {
                return $"VertexBufferLayoutItem of Type: {Type.Name}, Count: {Count}, Total size of: {Size * Count} bytes.";
            }
        }
    }


}
