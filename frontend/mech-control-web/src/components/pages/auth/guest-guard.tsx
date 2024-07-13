'use client';

import * as React from 'react';
import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import Alert from '@mui/material/Alert';
import { logger } from '@/lib/default-logger';
import { useUser } from '@/hooks/use-user';

export interface GuestGuardProps {
    children: React.ReactNode;
}

export function GuestGuard({ children }: GuestGuardProps): React.JSX.Element | null {
    const router = useRouter();
    const { user, error, isLoading } = useUser();
    const [isChecking, setIsChecking] = React.useState<boolean>(true);

    const checkPermissions = async (): Promise<void> => {
        if (isLoading) {
            return;
        }

        if (error) {
            setIsChecking(false);
            return;
        }

        if (user) {
            router.replace('/');
            return;
        }

        setIsChecking(false);
    };

    useEffect(() => {
        checkPermissions().catch(() => {});
    }, [user, error, isLoading]);

    if (isChecking) {
        return null;
    }

    if (error) {
        return <Alert color="error">{error}</Alert>;
    }

    return <React.Fragment>{children}</React.Fragment>;
}
