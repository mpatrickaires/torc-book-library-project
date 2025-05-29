import { useState } from 'react';
import type { Book, BookFilter } from '../types/Book';
import { useSnackbar } from './useSnackbar';

export function useFetchBooks() {
  const [isLoading, setIsLoading] = useState(false);
  const [books, setBooks] = useState<Book[]>([]);
  const snackbar = useSnackbar();

  async function fetchBooks(filter?: BookFilter): Promise<void> {
    try {
      setIsLoading(true);

      const params = filter && new URLSearchParams(filter).toString();
      const response = await fetch(`https://localhost:7218/books?${params}`);

      const data = await response.json();
      if (!response.ok) {
        console.error(data);
        snackbar.show(ERROR_MESSAGE);
        return;
      } else {
        setBooks(data);
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
    fetchBooks,
    books,
  };
}

const ERROR_MESSAGE = 'An unexpected error occurred while fetching the books';
