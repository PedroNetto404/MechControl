'use client';

import { useState } from 'react';
import CachedIcon from '@mui/icons-material/Cached';
import ContentCopyIcon from '@mui/icons-material/ContentCopy';
import { Alert, Button, Snackbar } from '@mui/material';

export type CopyButtonProps = {
    text: string;
};

export const CopyButton: React.FC<CopyButtonProps> = ({ text }) => {
    const [copying, setCopying] = useState(false);
    const [copyError, setCopyError] = useState(false);
    const [alertOpen, setAlertOpen] = useState(false);

    const copyToClipboard = async () => {
        setCopying(true);

        try {
            await new Promise((resolve) => setTimeout(resolve, 1000));
            await navigator.clipboard.writeText(text);
        } catch (error) {
            setCopyError(true);
        } finally {
            setCopying(false);
            setAlertOpen(true);

            setTimeout(() => {
                setAlertOpen(false);
                setCopyError(false);
            }, 3000);
        }
    };

    return (
        <>
            <Button variant="outlined" onClick={copyToClipboard} disabled={copying}>
                {copying ? <CachedIcon /> : <ContentCopyIcon />}
            </Button>
            <Snackbar open={alertOpen}>
                <Alert severity={copyError ? 'error' : 'success'}>{copyError ? 'Erro ao copiar' : 'Copiado!'}</Alert>
            </Snackbar>
        </>
    );
};
