import { createContext } from 'react';

export const SnackbarContext = createContext<
  | {
      show: (message: string) => void;
    }
  | undefined
>(undefined);
