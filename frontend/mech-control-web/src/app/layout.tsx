import * as React from 'react';

import { UserProvider } from '@/contexts/user-context';
import { ThemeProvider } from '@/components/pages/core/theme-provider/theme-provider';

interface LayoutProps {
    children: React.ReactNode;
}

const Layout: React.FC<LayoutProps> = ({ children }) => (
    <html lang="pt">
        <body>
            <UserProvider>
                <ThemeProvider>{children}</ThemeProvider>
            </UserProvider>
        </body>
    </html>
);

export default Layout;