import * as React from 'react';
import type { Metadata } from 'next';

import { config } from '@/config';
import { GuestGuard } from '@/components/pages/auth/guest-guard';
import { SignInForm } from '@/components/pages/auth/sign-in-form';

export const metadata = { title: `Login | ${config.site.name}` } satisfies Metadata;

const Page = (): React.JSX.Element => (
    <GuestGuard>
        <SignInForm />
    </GuestGuard>
);

export default Page;
