import * as React from 'react';
import RouterLink from 'next/link';
import Box from '@mui/material/Box';
import { DynamicLogo } from '@/components/pages/core/logo';

export interface LayoutProps {
    children: React.ReactNode;
}

const Layout: React.FC<LayoutProps> = ({ children }) => (
    <Box
        sx={{
            display: 'flex',
            flexDirection: 'column',
            minHeight: '100vh',
        }}
    >
        <Box sx={{ p: 3 }}>
            <Box component={RouterLink} href={'/'} sx={{ display: 'inline-block', fontSize: 0 }}>
                <DynamicLogo colorDark="light" colorLight="dark" height={32} width={122} />
            </Box>
        </Box>
        <Box
            sx={{
                display: 'flex',
                flex: '1 1 auto',
                justifyContent: 'center',
                alignItems: 'center',
                p: 3,
            }}
        >
            <Box sx={{ maxWidth: '450px', width: '100%' }}>{children}</Box>
        </Box>
    </Box>
);

export default Layout;