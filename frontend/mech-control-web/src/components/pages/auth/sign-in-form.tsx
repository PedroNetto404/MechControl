'use client';

import { useCallback, useState } from 'react';
import RouterLink from 'next/link';
import { useRouter } from 'next/navigation';
import { zodResolver } from '@hookform/resolvers/zod';
import Alert from '@mui/material/Alert';
import Button from '@mui/material/Button';
import FormControl from '@mui/material/FormControl';
import FormHelperText from '@mui/material/FormHelperText';
import InputLabel from '@mui/material/InputLabel';
import Link from '@mui/material/Link';
import OutlinedInput from '@mui/material/OutlinedInput';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import { Eye as EyeIcon } from '@phosphor-icons/react/dist/ssr/Eye';
import { EyeSlash as EyeSlashIcon } from '@phosphor-icons/react/dist/ssr/EyeSlash';
import { Controller, useForm } from 'react-hook-form';
import { z as zod } from 'zod';
import { authClient } from '@/lib/auth/client';
import { useUser } from '@/hooks/use-user';

const schema = zod.object({
    email: zod.string().min(1, { message: 'E-mail obrigatório' }).email(),
    password: zod.string().min(1, { message: 'Senha obrigatória' }),
});

type Values = zod.infer<typeof schema>;

export function SignInForm(): React.JSX.Element {
    const router = useRouter();
    const { checkSession } = useUser();
    const [showPassword, setShowPassword] = useState<boolean>();
    const [isPending, setIsPending] = useState<boolean>(false);

    const {
        control,
        handleSubmit,
        setError,
        formState: { errors },
    } = useForm<Values>({ resolver: zodResolver(schema) });

    const onSubmit = useCallback(
        async (values: Values): Promise<void> => {
            setIsPending(true);

            const { error } = await authClient.signInWithPassword(values);

            if (error) {
                setError('root', { type: 'server', message: error });
                setIsPending(false);
                return;
            }

            await checkSession?.();
            router.refresh();
        },
        [checkSession, router, setError]
    );

    return (
        <Stack spacing={4}>
            <Stack spacing={1}>
                <Typography variant="h4">Entrar</Typography>
            </Stack>
            <form onSubmit={handleSubmit(onSubmit)}>
                <Stack spacing={2}>
                    <Controller
                        control={control}
                        name="email"
                        render={({ field }) => (
                            <FormControl error={Boolean(errors.email)}>
                                <InputLabel>E-mail</InputLabel>
                                <OutlinedInput {...field} label="Email address" type="email" />
                                {errors.email ? <FormHelperText>{errors.email.message}</FormHelperText> : null}
                            </FormControl>
                        )}
                    />
                    <Controller
                        control={control}
                        name="password"
                        render={({ field }) => (
                            <FormControl error={Boolean(errors.password)}>
                                <InputLabel>Senha</InputLabel>
                                <OutlinedInput
                                    {...field}
                                    endAdornment={
                                        showPassword ? (
                                            <EyeIcon
                                                cursor="pointer"
                                                fontSize="var(--icon-fontSize-md)"
                                                onClick={(): void => {
                                                    setShowPassword(false);
                                                }}
                                            />
                                        ) : (
                                            <EyeSlashIcon
                                                cursor="pointer"
                                                fontSize="var(--icon-fontSize-md)"
                                                onClick={(): void => {
                                                    setShowPassword(true);
                                                }}
                                            />
                                        )
                                    }
                                    label="Password"
                                    type={showPassword ? 'text' : 'password'}
                                />
                                {errors.password ? <FormHelperText>{errors.password.message}</FormHelperText> : null}
                            </FormControl>
                        )}
                    />
                    <div>
                        <Link component={RouterLink} href={'/auth/reset-password'} variant="subtitle2">
                            Esqueceu sua senha?
                        </Link>
                    </div>
                    {errors.root ? <Alert color="error">{errors.root.message}</Alert> : null}
                    <Button disabled={isPending} type="submit" variant="contained">
                        {isPending ? 'Carregando...' : 'Entrar'}
                    </Button>
                </Stack>
            </form>
        </Stack>
    );
}
