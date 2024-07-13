'use client';

import { useState, useEffect } from 'react';
import RouterLink from 'next/link';
import { usePathname, useRouter } from 'next/navigation';
import { ExpandLess, ExpandMore } from '@mui/icons-material';
import DirectionsCarFilledIcon from '@mui/icons-material/DirectionsCarFilled';
import Person2Icon from '@mui/icons-material/Person2';
import {
    Collapse,
    Divider,
    Drawer,
    IconButton,
    List,
    ListItem,
    ListItemIcon,
    ListItemText,
    SvgIconTypeMap,
    useTheme,
} from '@mui/material';
import { OverridableComponent } from '@mui/material/OverridableComponent';
import { Box, Stack } from '@mui/system';
import { useMediaQuery } from '@mui/material';

import { Logo } from '@/components/pages/core/logo';

export type SideBarItem = {
    title: string;
    pagePath: string;
    icon: OverridableComponent<SvgIconTypeMap<{}, 'svg'>> & {
        muiName: string;
    };
    items?: SideBarItem[];
};

type SideBarItemProps = {
    item: SideBarItem;
    depth: number;
    showTitle?: boolean;
};

const SideBarItems: SideBarItem[] = [
    {
        title: 'Clientes',
        pagePath: '/pages/customers',
        icon: Person2Icon,
        items: [
            {
                title: 'Veículos',
                pagePath: '/pages/customers/vehicles',
                icon: DirectionsCarFilledIcon,
            },
        ],
    },
];

export const SideBarItem: React.FC<SideBarItemProps> = ({ item, depth = 0, showTitle }) => {
    const [open, setOpen] = useState(false);
    const hasSubItems = item.items && item.items.length > 0;
    const Icon = item.icon;
    const pathname = usePathname();
    const router = useRouter();
    const theme = useTheme();
    const activeColor = theme.palette.primary.main;
    const inactiveColor = theme.palette.text.secondary;

    const handleClick = () => {
        if (hasSubItems) {
            setOpen((prev) => !prev);
        }

        router.push(item.pagePath);
    };

    const isActive = pathname === item.pagePath;
    const ExpandIcon = open ? ExpandLess : ExpandMore;

    return (
        <>
            <ListItem button onClick={handleClick} sx={{ pl: `${depth * 2 + 1}rem`, pr: 2 }}>
                <ListItemIcon sx={{ minWidth: '40px' }}>
                    <Icon sx={{ color: isActive ? activeColor : inactiveColor }} />
                </ListItemIcon>
                {showTitle && (
                    <ListItemText primary={item.title} sx={{ color: isActive ? activeColor : inactiveColor }} />
                )}
                {hasSubItems && <ExpandIcon sx={{ color: isActive ? activeColor : inactiveColor }} />}
            </ListItem>
            {hasSubItems && (
                <Collapse in={open} timeout="auto" unmountOnExit>
                    <List component="div" disablePadding>
                        {item.items!.map((subItem) => (
                            <SideBarItem key={subItem.title} depth={depth + 1} item={subItem} showTitle={showTitle} />
                        ))}
                    </List>
                </Collapse>
            )}
        </>
    );
};

export const SideBar: React.FC<{ openNav: boolean; toggleNav: () => void }> = ({ openNav, toggleNav }) => {
    const isMobile = useMediaQuery((theme: any) => theme.breakpoints.down('lg'));

    useEffect(() => {
        const handleOutsideClick = (event: MouseEvent) => {
            if (isMobile && openNav && !(event.target as Element).closest('.MuiDrawer-paper')) {
                toggleNav();
            }
        };

        document.addEventListener('mousedown', handleOutsideClick);
        return () => {
            document.removeEventListener('mousedown', handleOutsideClick);
        };
    }, [isMobile, openNav, toggleNav]);

    return (
        <Box component="nav">
            <Drawer
                variant={isMobile ? 'temporary' : 'permanent'}
                sx={{
                    width: openNav ? 'var(--SideNav-width)' : '0px',
                    flexShrink: 0,
                    '& .MuiDrawer-paper': {
                        width: openNav ? 'var(--SideNav-width)' : '0px',
                        boxSizing: 'border-box',
                        overflowX: 'hidden',
                        transition: 'width 0.3s ease',
                    },
                }}
                open={openNav}
                onClose={toggleNav}
                onClick={(e) => {
                    if (isMobile && !(e.target as Element).closest('.MuiDrawer-paper')) {
                        toggleNav();
                    }
                }}
            >
                <Box
                    sx={{
                        '--SideNav-background': 'var(--mui-palette-neutral-950)',
                        '--SideNav-color': 'var(--mui-palette-common-white)',
                        '--NavItem-color': 'var(--mui-palette-neutral-300)',
                        '--NavItem-hover-background': 'rgba(255, 255, 255, 0.04)',
                        '--NavItem-active-background': 'var(--mui-palette-primary-main)',
                        '--NavItem-active-color': 'var(--mui-palette-primary-contrastText)',
                        '--NavItem-disabled-color': 'var(--mui-palette-neutral-500)',
                        '--NavItem-icon-color': 'var(--mui-palette-neutral-400)',
                        '--NavItem-icon-active-color': 'var(--mui-palette-primary-contrastText)',
                        '--NavItem-icon-disabled-color': 'var(--mui-palette-neutral-600)',
                        bgcolor: 'var(--SideNav-background)',
                        color: 'var(--SideNav-color)',
                        display: 'flex',
                        flexDirection: 'column',
                        height: '100%',
                        left: 0,
                        maxWidth: '100%',
                        position: 'fixed',
                        scrollbarWidth: 'none',
                        top: 0,
                        width: 'var(--SideNav-width)',
                        zIndex: 'var(--SideNav-zIndex)',
                        '&::-webkit-scrollbar': { display: 'none' },
                    }}
                >
                    <Box sx={{ p: 3 }}>
                        <Stack direction="row" justifyContent="space-between" alignItems="center" sx={{ mb: 2 }}>
                            <Box component={RouterLink} href={'/pages/customers'} sx={{ display: 'inline-flex' }}>
                            {/*TODO*/}
                            </Box>
                        </Stack>
                    </Box>
                    <Divider sx={{ borderColor: 'var(--mui-palette-neutral-700)' }} />
                    <Box component="nav" sx={{ flex: '1 1 auto', p: '12px' }}>
                        <List>
                            {SideBarItems.map((item) => (
                                <SideBarItem item={item} depth={0} key={item.title} showTitle={true} />
                            ))}
                        </List>
                    </Box>
                    <Divider sx={{ borderColor: 'var(--mui-palette-neutral-700)' }} />
                </Box>
            </Drawer>
        </Box>
    );
};
