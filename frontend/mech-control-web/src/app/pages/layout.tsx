'use client';

import * as React from 'react';
import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import GlobalStyles from '@mui/material/GlobalStyles';
import { AuthGuard } from '@/components/pages/auth/auth-guard';
import { AppBar } from '@/components/shared/app-bar';
import { SideBar } from '@/components/shared/side-bar';

interface LayoutProps {
    children: React.ReactNode;
}

const Layout: React.FC<LayoutProps> = ({ children }) => {
    const [openNav, setOpenNav] = React.useState<boolean>(false);

    const toggleNav = () => {
        setOpenNav((prev) => !prev);
    };

    return (
        <AuthGuard>
            <GlobalStyles
                styles={{
                    body: {
                        '--MainNav-height': '56px',
                        '--MainNav-zIndex': 1000,
                        '--SideNav-width': '280px',
                        '--SideNav-zIndex': 1100,
                        '--MobileNav-width': '320px',
                        '--MobileNav-zIndex': 1100,
                    },
                }}
            />
            <Box
                sx={{
                    bgcolor: 'var(--mui-palette-background-default)',
                    display: 'flex',
                    flexDirection: 'column',
                    position: 'relative',
                    minHeight: '100%',
                }}
            >
                <SideBar openNav={openNav} toggleNav={toggleNav} />
                <Box
                    sx={{
                        display: 'flex',
                        flex: '1 1 auto',
                        flexDirection: 'column',
                        pl: { lg: 'var(--SideNav-width)' },
                    }}
                >
                    <AppBar toggleNav={toggleNav} />
                    <main>
                        <Container maxWidth="xl" sx={{ py: '64px' }}>
                            {children}
                        </Container>
                    </main>
                </Box>
            </Box>
        </AuthGuard>
    );
};

export default Layout;
