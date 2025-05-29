import {
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  Container,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  TextField,
  Typography,
} from '@mui/material';
import { useEffect, useState } from 'react';
import { useFetcher } from './hooks/useFetcher';
import type { Book, BookFilter } from './types/Book';

function App() {
  const { searchBy, searchValue, setSearchBy, setSearchValue } = useSearch();

  const fetcherBooks = useFetcher<Book[]>('/books');
  const fetcherBookTypes = useFetcher<string[]>('/books/types');
  const fetcherBookCategories = useFetcher<string[]>('/books/categories');

  useEffect(() => {
    fetcherBooks.load();
    fetcherBookTypes.load();
    fetcherBookCategories.load();
  }, []);

  function getSearchValueInput() {
    if (searchBy !== 'type' && searchBy !== 'category') {
      return (
        <TextField
          value={searchValue}
          onChange={e => setSearchValue(e.target.value)}
          label="Search Value"
        />
      );
    }

    const fetcher =
      searchBy === 'type' ? fetcherBookTypes : fetcherBookCategories;
    return (
      <>
        <InputLabel>Search Value</InputLabel>
        <Select
          value={searchValue}
          onChange={e => setSearchValue(e.target.value as string)}
          label="Search Value"
        >
          {fetcher.data?.map(type => (
            <MenuItem value={type}>{type}</MenuItem>
          ))}
        </Select>
      </>
    );
  }

  return (
    <Container>
      <Typography variant="h1" fontSize={36}>
        Torc Book Library
      </Typography>
      <Card sx={{ maxWidth: 500 }}>
        <CardContent>
          <form
            onSubmit={e => {
              e.preventDefault();
              const filter =
                searchBy && searchValue
                  ? ({ [searchBy]: searchValue } satisfies BookFilter)
                  : undefined;
              fetcherBooks.load(filter);
            }}
          >
            <Box maxWidth={1 / 2} display="flex" flexDirection="column" gap={4}>
              <FormControl>
                <InputLabel>Search By</InputLabel>
                <Select
                  value={searchBy}
                  onChange={e => {
                    const value = e.target.value;
                    if (isValidSearchByValue(value)) {
                      setSearchBy(value);
                    }
                  }}
                  label="Search By"
                >
                  {searchByOptions.map(({ value, label }) => (
                    <MenuItem value={value}>{label}</MenuItem>
                  ))}
                </Select>
              </FormControl>
              <FormControl>{getSearchValueInput()}</FormControl>
              <Button
                loading={fetcherBooks.isLoading}
                type="submit"
                variant="contained"
                sx={{ maxWidth: 1 / 2 }}
              >
                Search
              </Button>
            </Box>
          </form>
        </CardContent>
        <CardActions></CardActions>
      </Card>
      <TableContainer>
        <Table>
          <TableHead>
            <TableCell>Title</TableCell>
            <TableCell>Author</TableCell>
            <TableCell>Type</TableCell>
            <TableCell>ISBN</TableCell>
            <TableCell>Category</TableCell>
            <TableCell>Available Copies</TableCell>
          </TableHead>
          <TableBody>
            {fetcherBooks.data?.map(
              ({
                title,
                author,
                type,
                isbn,
                category,
                availableCopies,
                totalCopies,
              }) => (
                <TableRow>
                  <TableCell>{title}</TableCell>
                  <TableCell>{author}</TableCell>
                  <TableCell>{type}</TableCell>
                  <TableCell>{isbn || '-'}</TableCell>
                  <TableCell>{category || '-'}</TableCell>
                  <TableCell>{`${availableCopies}/${totalCopies}`}</TableCell>
                </TableRow>
              )
            )}
          </TableBody>
        </Table>
      </TableContainer>
    </Container>
  );
}

function useSearch() {
  const [searchBy, setSearchBy] = useState<keyof BookFilter | ''>('');
  const [searchValue, setSearchValue] = useState<string>('');

  return {
    searchBy,
    searchValue,
    setSearchValue,
    setSearchBy: (value: typeof searchBy) => {
      setSearchValue('');
      setSearchBy(value);
    },
  };
}

const searchByOptions = [
  { value: 'title', label: 'Title' },
  { value: 'author', label: 'Author' },
  { value: 'type', label: 'Type' },
  { value: 'isbn', label: 'ISBN' },
  { value: 'category', label: 'Category' },
] as const satisfies Array<{ value: keyof BookFilter; label: string }>;

const searchByValues = searchByOptions.map(({ value }) => value);

function isValidSearchByValue(
  value: unknown
): value is (typeof searchByValues)[number] {
  return searchByValues.some(searchByValue => searchByValue === value);
}

export default App;
