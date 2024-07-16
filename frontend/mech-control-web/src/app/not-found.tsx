import * as React from 'react';
import type { Metadata } from 'next';
import RouterLink from 'next/link';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import { ArrowLeft as ArrowLeftIcon } from '@phosphor-icons/react/dist/ssr/ArrowLeft';
import { config } from '@/config';

export const metadata = { title: `Não encontrado | ${config.site.name}` } satisfies Metadata;

export default function NotFound(): React.JSX.Element {
  return (
    <Box component="main" sx={{ alignItems: 'center', display: 'flex', justifyContent: 'center', minHeight: '100vh' }}>
      <Stack spacing={3} sx={{ alignItems: 'center', maxWidth: 'md', textAlign: 'center' }}>
        <Box>
          <Box
            component="img"
            alt="Erro 404"
            src="/assets/error-404.png"
            sx={{ display: 'inline-block', height: 'auto', maxWidth: '100%', width: '400px' }}
          />
        </Box>
        <Typography variant="h3">
          404: A página que você está procurando não está aqui
        </Typography>
        <Typography color="text.secondary" variant="body1">
          Você tentou uma rota incorreta ou chegou aqui por engano. Seja qual for o caso, tente usar a navegação
        </Typography>
        <Button
          component={RouterLink}
          href={'/'}
          startIcon={<ArrowLeftIcon fontSize="var(--icon-fontSize-md)" />}
          variant="contained"
        >
          Voltar para a home
        </Button>
      </Stack>
    </Box>
  );
}
