import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import App from './App.tsx';
import { SnackbarProvider } from './context/snackbar/SnackbarProvider.tsx';

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <SnackbarProvider>
      <App />
    </SnackbarProvider>
  </StrictMode>
);
