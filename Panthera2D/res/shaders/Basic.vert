#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec4 aColor;
layout (location = 2) in vec2 texUV;

uniform mat4 WP;

out vec4 color;
out vec2 uv;

void main()
{
    gl_Position = vec4(aPos, 1.0) * WP;

	color = aColor;
	uv = texUV;
}