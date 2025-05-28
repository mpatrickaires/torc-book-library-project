import { useState } from 'react';
import type { Book, BookFilter } from '../types/Book';

export function useFetchBooks() {
  const [isLoading, setIsLoading] = useState(false);
  const [books, setBooks] = useState<Book[]>([]);

  async function fetchBooks(filter?: BookFilter): Promise<void> {
    try {
      setIsLoading(true);

      const params = filter && new URLSearchParams(filter).toString();
      const response = await fetch(`https://localhost:7218/books?${params}`);

      const data = await response.json();
      if (!response.ok) {
        console.error(data);
        return;
      } else {
        setBooks(data);
      }
    } catch (error) {
      console.error(error);
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
