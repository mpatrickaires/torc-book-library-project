import { useState } from 'react';
import type { Book, BookFilter } from '../types/Book';
import { useSnackbar } from './useSnackbar';

export function useFetcher<TData>(route: string) {
  const [isLoading, setIsLoading] = useState(false);
  const [data, setData] = useState<TData | null>(null);
  const snackbar = useSnackbar();

  async function load(
    params?: ConstructorParameters<typeof URLSearchParams>[0]
  ): Promise<void> {
    try {
      setIsLoading(true);

      const searchParams = params ? new URLSearchParams(params).toString() : '';
      const response = await fetch(
        `https://localhost:7218${route}?${searchParams}`
      );

      const data = await response.json();
      if (!response.ok) {
        console.error(data);
        snackbar.show(ERROR_MESSAGE);
        return;
      } else {
        setData(data);
      }
    } catch (error) {
      console.error(error);
      snackbar.show(ERROR_MESSAGE);
    } finally {
      setIsLoading(false);
    }
  }

  return {
    isLoading,
    load,
    data,
  };
}

const ERROR_MESSAGE = 'An unexpected error occurred';
