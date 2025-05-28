export type Book = {
  title: string;
  author: string;
  totalCopies: number;
  availableCopies: number;
  type?: string;
  isbn?: string;
  category?: string;
};

export type BookFilter = Partial<
  Pick<Book, 'title' | 'author' | 'type' | 'isbn' | 'category'>
>;
