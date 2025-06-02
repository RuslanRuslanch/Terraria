#version 460 core

in vec2 fUVs;

uniform sampler2D textureUnit;

out vec4 outColor;

void main()
{
	vec4 color = texture(textureUnit, fUVs);

	if (color.a == 0)
	{
		discard;
	}

	outColor = color;
}