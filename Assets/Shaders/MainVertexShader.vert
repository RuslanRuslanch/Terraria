#version 460 core

in vec3 vPosition;
in vec2 vUVs;

uniform mat4 projection;
uniform mat4 view;
uniform mat4 model;

out vec2 fUVs;

void main()
{
	gl_Position = vec4(vPosition, 1.0) * model * view * projection;
	
	fUVs = vUVs;
}