/* eslint-disable */
import { TypedDocumentNode as DocumentNode } from '@graphql-typed-document-node/core';
export type Maybe<T> = T | null;
export type InputMaybe<T> = Maybe<T>;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
export type MakeEmpty<T extends { [key: string]: unknown }, K extends keyof T> = { [_ in K]?: never };
export type Incremental<T> = T | { [P in keyof T]?: P extends ' $fragmentName' | '__typename' ? T[P] : never };
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: { input: string; output: string; }
  String: { input: string; output: string; }
  Boolean: { input: boolean; output: boolean; }
  Int: { input: number; output: number; }
  Float: { input: number; output: number; }
  /** The `DateTime` scalar represents an ISO-8601 compliant date time type. */
  DateTime: { input: any; output: any; }
  UUID: { input: any; output: any; }
};

export type AddBookInput = {
  authorId: Scalars['UUID']['input'];
  genre: GenreEnum;
  title: Scalars['String']['input'];
};

export type AddBookReviewInput = {
  bookID: Scalars['UUID']['input'];
  rating: Scalars['Int']['input'];
  reviewText: InputMaybe<Scalars['String']['input']>;
  reviewerID: Scalars['UUID']['input'];
};

export type AddPersonInput = {
  bio: InputMaybe<Scalars['String']['input']>;
  email: Scalars['String']['input'];
  firstName: Scalars['String']['input'];
  lastName: Scalars['String']['input'];
};

export type Author = {
  __typename?: 'Author';
  books: Array<Book>;
  id: Scalars['UUID']['output'];
  person: Person;
  personID: Scalars['UUID']['output'];
};

export type AuthorFilterInput = {
  and: InputMaybe<Array<AuthorFilterInput>>;
  books: InputMaybe<ListFilterInputTypeOfBookFilterInput>;
  id: InputMaybe<UuidOperationFilterInput>;
  or: InputMaybe<Array<AuthorFilterInput>>;
  person: InputMaybe<PersonFilterInput>;
  personID: InputMaybe<UuidOperationFilterInput>;
};

export type AuthorSortInput = {
  id: InputMaybe<SortEnumType>;
  person: InputMaybe<PersonSortInput>;
  personID: InputMaybe<SortEnumType>;
};

export type Book = {
  __typename?: 'Book';
  author: Author;
  authorID: Scalars['UUID']['output'];
  bookEditions: Array<BookEdition>;
  bookReviews: Array<BookReview>;
  genre: GenreEnum;
  id: Scalars['UUID']['output'];
  title: Scalars['String']['output'];
};

export type BookEdition = {
  __typename?: 'BookEdition';
  book: Book;
  bookID: Scalars['UUID']['output'];
  editionNumber: Scalars['Int']['output'];
  format: FormatEnum;
  id: Scalars['UUID']['output'];
  publicationDate: Scalars['DateTime']['output'];
  publisher: PublishingHouse;
  publisherID: Scalars['UUID']['output'];
};

export type BookEditionFilterInput = {
  and: InputMaybe<Array<BookEditionFilterInput>>;
  book: InputMaybe<BookFilterInput>;
  bookID: InputMaybe<UuidOperationFilterInput>;
  editionNumber: InputMaybe<IntOperationFilterInput>;
  format: InputMaybe<FormatEnumOperationFilterInput>;
  id: InputMaybe<UuidOperationFilterInput>;
  or: InputMaybe<Array<BookEditionFilterInput>>;
  publicationDate: InputMaybe<DateTimeOperationFilterInput>;
  publisher: InputMaybe<PublishingHouseFilterInput>;
  publisherID: InputMaybe<UuidOperationFilterInput>;
};

export type BookFilterInput = {
  and: InputMaybe<Array<BookFilterInput>>;
  author: InputMaybe<AuthorFilterInput>;
  authorID: InputMaybe<UuidOperationFilterInput>;
  bookEditions: InputMaybe<ListFilterInputTypeOfBookEditionFilterInput>;
  bookReviews: InputMaybe<ListFilterInputTypeOfBookReviewFilterInput>;
  genre: InputMaybe<GenreEnumOperationFilterInput>;
  id: InputMaybe<UuidOperationFilterInput>;
  or: InputMaybe<Array<BookFilterInput>>;
  title: InputMaybe<StringOperationFilterInput>;
};

export type BookReview = {
  __typename?: 'BookReview';
  book: Book;
  bookID: Scalars['UUID']['output'];
  id: Scalars['UUID']['output'];
  rating: Scalars['Int']['output'];
  reviewDate: Scalars['DateTime']['output'];
  reviewText: Scalars['String']['output'];
  reviewer: Reviewer;
  reviewerID: Scalars['UUID']['output'];
};

export type BookReviewFilterInput = {
  and: InputMaybe<Array<BookReviewFilterInput>>;
  book: InputMaybe<BookFilterInput>;
  bookID: InputMaybe<UuidOperationFilterInput>;
  id: InputMaybe<UuidOperationFilterInput>;
  or: InputMaybe<Array<BookReviewFilterInput>>;
  rating: InputMaybe<IntOperationFilterInput>;
  reviewDate: InputMaybe<DateTimeOperationFilterInput>;
  reviewText: InputMaybe<StringOperationFilterInput>;
  reviewer: InputMaybe<ReviewerFilterInput>;
  reviewerID: InputMaybe<UuidOperationFilterInput>;
};

export type BookReviewSortInput = {
  book: InputMaybe<BookSortInput>;
  bookID: InputMaybe<SortEnumType>;
  id: InputMaybe<SortEnumType>;
  rating: InputMaybe<SortEnumType>;
  reviewDate: InputMaybe<SortEnumType>;
  reviewText: InputMaybe<SortEnumType>;
  reviewer: InputMaybe<ReviewerSortInput>;
  reviewerID: InputMaybe<SortEnumType>;
};

export type BookSortInput = {
  author: InputMaybe<AuthorSortInput>;
  authorID: InputMaybe<SortEnumType>;
  genre: InputMaybe<SortEnumType>;
  id: InputMaybe<SortEnumType>;
  title: InputMaybe<SortEnumType>;
};

export type DateTimeOperationFilterInput = {
  eq: InputMaybe<Scalars['DateTime']['input']>;
  gt: InputMaybe<Scalars['DateTime']['input']>;
  gte: InputMaybe<Scalars['DateTime']['input']>;
  in: InputMaybe<Array<InputMaybe<Scalars['DateTime']['input']>>>;
  lt: InputMaybe<Scalars['DateTime']['input']>;
  lte: InputMaybe<Scalars['DateTime']['input']>;
  neq: InputMaybe<Scalars['DateTime']['input']>;
  ngt: InputMaybe<Scalars['DateTime']['input']>;
  ngte: InputMaybe<Scalars['DateTime']['input']>;
  nin: InputMaybe<Array<InputMaybe<Scalars['DateTime']['input']>>>;
  nlt: InputMaybe<Scalars['DateTime']['input']>;
  nlte: InputMaybe<Scalars['DateTime']['input']>;
};

export enum FormatEnum {
  Audiobook = 'AUDIOBOOK',
  EBook = 'E_BOOK',
  Hardcover = 'HARDCOVER',
  Paperback = 'PAPERBACK'
}

export type FormatEnumOperationFilterInput = {
  eq: InputMaybe<FormatEnum>;
  in: InputMaybe<Array<FormatEnum>>;
  neq: InputMaybe<FormatEnum>;
  nin: InputMaybe<Array<FormatEnum>>;
};

export enum GenreEnum {
  Biography = 'BIOGRAPHY',
  Fantasy = 'FANTASY',
  Fiction = 'FICTION',
  Mystery = 'MYSTERY',
  NonFiction = 'NON_FICTION',
  ScienceFiction = 'SCIENCE_FICTION'
}

export type GenreEnumOperationFilterInput = {
  eq: InputMaybe<GenreEnum>;
  in: InputMaybe<Array<GenreEnum>>;
  neq: InputMaybe<GenreEnum>;
  nin: InputMaybe<Array<GenreEnum>>;
};

export type IntOperationFilterInput = {
  eq: InputMaybe<Scalars['Int']['input']>;
  gt: InputMaybe<Scalars['Int']['input']>;
  gte: InputMaybe<Scalars['Int']['input']>;
  in: InputMaybe<Array<InputMaybe<Scalars['Int']['input']>>>;
  lt: InputMaybe<Scalars['Int']['input']>;
  lte: InputMaybe<Scalars['Int']['input']>;
  neq: InputMaybe<Scalars['Int']['input']>;
  ngt: InputMaybe<Scalars['Int']['input']>;
  ngte: InputMaybe<Scalars['Int']['input']>;
  nin: InputMaybe<Array<InputMaybe<Scalars['Int']['input']>>>;
  nlt: InputMaybe<Scalars['Int']['input']>;
  nlte: InputMaybe<Scalars['Int']['input']>;
};

export type ListFilterInputTypeOfBookEditionFilterInput = {
  all: InputMaybe<BookEditionFilterInput>;
  any: InputMaybe<Scalars['Boolean']['input']>;
  none: InputMaybe<BookEditionFilterInput>;
  some: InputMaybe<BookEditionFilterInput>;
};

export type ListFilterInputTypeOfBookFilterInput = {
  all: InputMaybe<BookFilterInput>;
  any: InputMaybe<Scalars['Boolean']['input']>;
  none: InputMaybe<BookFilterInput>;
  some: InputMaybe<BookFilterInput>;
};

export type ListFilterInputTypeOfBookReviewFilterInput = {
  all: InputMaybe<BookReviewFilterInput>;
  any: InputMaybe<Scalars['Boolean']['input']>;
  none: InputMaybe<BookReviewFilterInput>;
  some: InputMaybe<BookReviewFilterInput>;
};

export type Mutation = {
  __typename?: 'Mutation';
  addAuthor: Author;
  /** Add a new book */
  addBook: Book;
  addBookReview: BookReview;
  addPerson: Person;
  addReviewer: Reviewer;
  updateBookTitle: Book;
};


export type MutationAddAuthorArgs = {
  personId: Scalars['UUID']['input'];
};


export type MutationAddBookArgs = {
  input: AddBookInput;
};


export type MutationAddBookReviewArgs = {
  input: AddBookReviewInput;
};


export type MutationAddPersonArgs = {
  input: AddPersonInput;
};


export type MutationAddReviewerArgs = {
  personId: Scalars['UUID']['input'];
};


export type MutationUpdateBookTitleArgs = {
  bookId: Scalars['UUID']['input'];
  title: Scalars['String']['input'];
};

export type Person = {
  __typename?: 'Person';
  author: Maybe<Author>;
  bio: Scalars['String']['output'];
  email: Scalars['String']['output'];
  firstName: Scalars['String']['output'];
  fullName: Scalars['String']['output'];
  id: Scalars['UUID']['output'];
  lastName: Scalars['String']['output'];
  reviewer: Maybe<Reviewer>;
};

export type PersonFilterInput = {
  and: InputMaybe<Array<PersonFilterInput>>;
  author: InputMaybe<AuthorFilterInput>;
  bio: InputMaybe<StringOperationFilterInput>;
  email: InputMaybe<StringOperationFilterInput>;
  firstName: InputMaybe<StringOperationFilterInput>;
  fullName: InputMaybe<StringOperationFilterInput>;
  id: InputMaybe<UuidOperationFilterInput>;
  lastName: InputMaybe<StringOperationFilterInput>;
  or: InputMaybe<Array<PersonFilterInput>>;
  reviewer: InputMaybe<ReviewerFilterInput>;
};

export type PersonSortInput = {
  author: InputMaybe<AuthorSortInput>;
  bio: InputMaybe<SortEnumType>;
  email: InputMaybe<SortEnumType>;
  firstName: InputMaybe<SortEnumType>;
  fullName: InputMaybe<SortEnumType>;
  id: InputMaybe<SortEnumType>;
  lastName: InputMaybe<SortEnumType>;
  reviewer: InputMaybe<ReviewerSortInput>;
};

export type PublishingHouse = {
  __typename?: 'PublishingHouse';
  address: Scalars['String']['output'];
  bookEditions: Array<BookEdition>;
  country: Scalars['String']['output'];
  id: Scalars['UUID']['output'];
  name: Scalars['String']['output'];
};

export type PublishingHouseFilterInput = {
  address: InputMaybe<StringOperationFilterInput>;
  and: InputMaybe<Array<PublishingHouseFilterInput>>;
  bookEditions: InputMaybe<ListFilterInputTypeOfBookEditionFilterInput>;
  country: InputMaybe<StringOperationFilterInput>;
  id: InputMaybe<UuidOperationFilterInput>;
  name: InputMaybe<StringOperationFilterInput>;
  or: InputMaybe<Array<PublishingHouseFilterInput>>;
};

export type Query = {
  __typename?: 'Query';
  allRewiews: Array<BookReview>;
  authors: Array<Author>;
  bookRewiews: Array<BookReview>;
  /** Get a list of books */
  books: Array<Book>;
  persons: Array<Person>;
  reviewers: Array<Reviewer>;
  /** Get the total count of books */
  totalBooks: Scalars['Int']['output'];
  totalRewiewsCount: Scalars['Int']['output'];
};


export type QueryAllRewiewsArgs = {
  order: InputMaybe<Array<BookReviewSortInput>>;
  where: InputMaybe<BookReviewFilterInput>;
};


export type QueryAuthorsArgs = {
  order: InputMaybe<Array<AuthorSortInput>>;
  where: InputMaybe<AuthorFilterInput>;
};


export type QueryBookRewiewsArgs = {
  bookId: Scalars['UUID']['input'];
  order: InputMaybe<Array<BookReviewSortInput>>;
  where: InputMaybe<BookReviewFilterInput>;
};


export type QueryBooksArgs = {
  order: InputMaybe<Array<BookSortInput>>;
  where: InputMaybe<BookFilterInput>;
};


export type QueryPersonsArgs = {
  order: InputMaybe<Array<PersonSortInput>>;
  where: InputMaybe<PersonFilterInput>;
};


export type QueryReviewersArgs = {
  order: InputMaybe<Array<ReviewerSortInput>>;
  where: InputMaybe<ReviewerFilterInput>;
};

export type Reviewer = {
  __typename?: 'Reviewer';
  bookReviews: Array<BookReview>;
  id: Scalars['UUID']['output'];
  person: Person;
  personID: Scalars['UUID']['output'];
};

export type ReviewerFilterInput = {
  and: InputMaybe<Array<ReviewerFilterInput>>;
  bookReviews: InputMaybe<ListFilterInputTypeOfBookReviewFilterInput>;
  id: InputMaybe<UuidOperationFilterInput>;
  or: InputMaybe<Array<ReviewerFilterInput>>;
  person: InputMaybe<PersonFilterInput>;
  personID: InputMaybe<UuidOperationFilterInput>;
};

export type ReviewerSortInput = {
  id: InputMaybe<SortEnumType>;
  person: InputMaybe<PersonSortInput>;
  personID: InputMaybe<SortEnumType>;
};

export enum SortEnumType {
  Asc = 'ASC',
  Desc = 'DESC'
}

export type StringOperationFilterInput = {
  and: InputMaybe<Array<StringOperationFilterInput>>;
  contains: InputMaybe<Scalars['String']['input']>;
  endsWith: InputMaybe<Scalars['String']['input']>;
  eq: InputMaybe<Scalars['String']['input']>;
  in: InputMaybe<Array<InputMaybe<Scalars['String']['input']>>>;
  ncontains: InputMaybe<Scalars['String']['input']>;
  nendsWith: InputMaybe<Scalars['String']['input']>;
  neq: InputMaybe<Scalars['String']['input']>;
  nin: InputMaybe<Array<InputMaybe<Scalars['String']['input']>>>;
  nstartsWith: InputMaybe<Scalars['String']['input']>;
  or: InputMaybe<Array<StringOperationFilterInput>>;
  startsWith: InputMaybe<Scalars['String']['input']>;
};

export type Subscription = {
  __typename?: 'Subscription';
  onBookAdded: Book;
};

export type UuidOperationFilterInput = {
  eq: InputMaybe<Scalars['UUID']['input']>;
  gt: InputMaybe<Scalars['UUID']['input']>;
  gte: InputMaybe<Scalars['UUID']['input']>;
  in: InputMaybe<Array<InputMaybe<Scalars['UUID']['input']>>>;
  lt: InputMaybe<Scalars['UUID']['input']>;
  lte: InputMaybe<Scalars['UUID']['input']>;
  neq: InputMaybe<Scalars['UUID']['input']>;
  ngt: InputMaybe<Scalars['UUID']['input']>;
  ngte: InputMaybe<Scalars['UUID']['input']>;
  nin: InputMaybe<Array<InputMaybe<Scalars['UUID']['input']>>>;
  nlt: InputMaybe<Scalars['UUID']['input']>;
  nlte: InputMaybe<Scalars['UUID']['input']>;
};

export type GetBooksQueryVariables = Exact<{ [key: string]: never; }>;


export type GetBooksQuery = { __typename?: 'Query', totalRewiewsCount: number, totalBooks: number, books: Array<{ __typename?: 'Book', id: any, title: string, genre: GenreEnum, author: { __typename?: 'Author', person: { __typename?: 'Person', firstName: string, lastName: string, fullName: string } } }> };


export const GetBooksDocument = {"kind":"Document","definitions":[{"kind":"OperationDefinition","operation":"query","name":{"kind":"Name","value":"GetBooks"},"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"totalRewiewsCount"}},{"kind":"Field","name":{"kind":"Name","value":"totalBooks"}},{"kind":"Field","name":{"kind":"Name","value":"books"},"arguments":[{"kind":"Argument","name":{"kind":"Name","value":"order"},"value":{"kind":"ListValue","values":[{"kind":"ObjectValue","fields":[{"kind":"ObjectField","name":{"kind":"Name","value":"title"},"value":{"kind":"EnumValue","value":"ASC"}}]}]}},{"kind":"Argument","name":{"kind":"Name","value":"where"},"value":{"kind":"ObjectValue","fields":[{"kind":"ObjectField","name":{"kind":"Name","value":"title"},"value":{"kind":"ObjectValue","fields":[{"kind":"ObjectField","name":{"kind":"Name","value":"contains"},"value":{"kind":"StringValue","value":"","block":false}}]}}]}}],"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"id"}},{"kind":"Field","name":{"kind":"Name","value":"title"}},{"kind":"Field","name":{"kind":"Name","value":"genre"}},{"kind":"Field","name":{"kind":"Name","value":"author"},"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"person"},"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"firstName"}},{"kind":"Field","name":{"kind":"Name","value":"lastName"}},{"kind":"Field","name":{"kind":"Name","value":"fullName"}}]}}]}}]}}]}}]} as unknown as DocumentNode<GetBooksQuery, GetBooksQueryVariables>;