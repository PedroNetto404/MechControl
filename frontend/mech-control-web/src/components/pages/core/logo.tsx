// Logo.tsx
'use client';

import * as React from 'react';
import Box from '@mui/material/Box';
import { useColorScheme } from '@mui/material/styles';

import { NoSsr } from '@/components/pages/core/no-ssr';

const HEIGHT = 60;
const WIDTH = 60;

type Color = 'dark' | 'light';

export interface LogoProps {
    color?: Color;
    emblem?: boolean;
    height?: number;
    width?: number;
}

export function Logo({ color = 'dark', height = HEIGHT, width = WIDTH }: LogoProps): React.JSX.Element {
    const logoSVG = `
    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 64 64" width="${width}" height="${height}">
      <circle cx="32" cy="32" r="32" fill="${color === 'light' ? '#ffffff' : '#000000'}"/>
      <text x="50%" y="50%" font-size="16" text-anchor="middle" fill="${color === 'light' ? '#000000' : '#ffffff'}" dy=".3em">CSC</text>
      <text x="50%" y="65%" font-size="8" text-anchor="middle" fill="${color === 'light' ? '#000000' : '#ffffff'}" dy=".3em">Service Car</text>
    </svg>
  `;

    return <Box component="div" dangerouslySetInnerHTML={{ __html: logoSVG }} sx={{ height, width }} />;
}

export interface DynamicLogoProps {
    colorDark?: Color;
    colorLight?: Color;
    height?: number;
    width?: number;
}

export function DynamicLogo({
    colorDark = 'light',
    colorLight = 'dark',
    height = HEIGHT,
    width = WIDTH,
    ...props
}: DynamicLogoProps): React.JSX.Element {
    const { colorScheme } = useColorScheme();
    const color = colorScheme === 'dark' ? colorDark : colorLight;

    return (
        <NoSsr fallback={<Box sx={{ height: `${height}px`, width: `${width}px` }} />}>
            <Logo color={color} height={height} width={width} {...props} />
        </NoSsr>
    );
}
