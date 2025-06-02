#version 460 core

in vec3 vPosition;
in vec2 vUVs;

out vec2 fUVs;

void main()
{
	gl_Position = vec4(vPosition, 1.0);
	
	fUVs = vUVs;
}