'use client';

import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Badge from '@mui/material/Badge';
import Box from '@mui/material/Box';
import IconButton from '@mui/material/IconButton';
import Stack from '@mui/material/Stack';
import Tooltip from '@mui/material/Tooltip';
import { Bell as BellIcon, List as ListIcon, MagnifyingGlass as MagnifyingGlassIcon } from '@phosphor-icons/react/dist/ssr';

import { usePopover } from '@/hooks/use-popover';
import { ThemeSwitch } from '@/components/shared/theme-switch';
import { UserPopover } from '../pages/layout/user-popover';

export const AppBar: React.FC<{ toggleNav: () => void }> = ({ toggleNav }) => {
    const userPopover = usePopover<HTMLDivElement>();

    return (
        <React.Fragment>
            <Box
                component="header"
                sx={{
                    borderBottom: '1px solid var(--mui-palette-divider)',
                    backgroundColor: 'var(--mui-palette-background-paper)',
                    position: 'sticky',
                    top: 0,
                    zIndex: 'var(--mui-zIndex-appBar)',
                }}
            >
                <Stack
                    direction="row"
                    spacing={2}
                    sx={{ alignItems: 'center', justifyContent: 'space-between', minHeight: '64px', px: 2 }}
                >
                    <Stack sx={{ alignItems: 'center' }} direction="row" spacing={2}>
                        <IconButton
                            onClick={(): void => {
                                toggleNav();
                            }}
                            sx={{ display: { lg: 'none' } }}
                        >
                            <ListIcon />
                        </IconButton>
                        <Tooltip title="Pesquisar">
                            <IconButton>
                                <MagnifyingGlassIcon />
                            </IconButton>
                        </Tooltip>
                    </Stack>
                    <Stack sx={{ alignItems: 'center' }} direction="row" spacing={2}>
                        <Tooltip title="Trocar tema">
                            <ThemeSwitch />
                        </Tooltip>
                        <Tooltip title="Notificações">
                            <Badge badgeContent={4} color="success" variant="dot">
                                <IconButton>
                                    <BellIcon />
                                </IconButton>
                            </Badge>
                        </Tooltip>
                        <Avatar
                            onClick={userPopover.handleOpen}
                            ref={userPopover.anchorRef}
                            src="/assets/avatar.png"
                            sx={{ cursor: 'pointer' }}
                        />
                    </Stack>
                </Stack>
            </Box>
            <UserPopover
                anchorEl={userPopover.anchorRef.current}
                onClose={userPopover.handleClose}
                open={userPopover.open}
            />
        </React.Fragment>
    );
};
