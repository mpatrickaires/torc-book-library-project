import { Alert, Snackbar } from '@mui/material';
import { useState, type PropsWithChildren } from 'react';
import { SnackbarContext } from './SnackbarContext';

export function SnackbarProvider({ children }: PropsWithChildren) {
  const [isOpen, setIsOpen] = useState(false);
  const [displayMessage, setDisplayMessage] = useState<string | null>(null);

  function show(message: string): void {
    setDisplayMessage(message);
    setIsOpen(true);
  }

  function onClose(): void {
    setIsOpen(false);
    setDisplayMessage(null);
  }

  return (
    <SnackbarContext value={{ show }}>
      {children}
      <Snackbar
        open={isOpen}
        onClose={onClose}
        autoHideDuration={5000}
        anchorOrigin={{ vertical: 'top', horizontal: 'center' }}
        slotProps={{
          clickAwayListener: { mouseEvent: false },
        }}
      >
        <Alert severity="error">{displayMessage}</Alert>
      </Snackbar>
    </SnackbarContext>
  );
}
