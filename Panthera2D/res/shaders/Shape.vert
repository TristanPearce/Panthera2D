#version 450 core
layout (location = 0) in vec2 aPos;
layout (location = 1) in vec4 aColor;

uniform mat4 uProjectionMatrix;

out vec4 ourColor;

void main()
{
    gl_Position = uProjectionMatrix * vec4(aPos, 0.0, 1.0);
    ourColor = aColor;
}