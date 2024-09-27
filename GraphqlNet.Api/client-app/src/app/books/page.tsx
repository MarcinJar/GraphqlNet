'use client'
import DefaultLayout from "@/components/layout/DefaultLayout";
import TableWrapper from "@/components/ui/table/tableWrapper/TableWrapper";
import Td from "@/components/ui/table/td/Td";
import Th from "@/components/ui/table/th/Th";
import { gql, useQuery } from '@apollo/client';

// Define GraphQL query
const GET_DATA = gql`
  query GetBooks {
    totalRewiewsCount
    totalBooks
    books(order: [{ title: ASC }], where: { title: { contains: "" } }) {
      id
      title
      genre
      author {
        person {
          firstName
          lastName
          fullName
        }
      }
    }
  }
`;

export default function Books() {
  const { loading, error, data } = useQuery(GET_DATA);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  console.log(data);

  return <DefaultLayout title="Books">
    <TableWrapper>
      <thead>
        <tr>
          <Th>Imię</Th>
          <Th>Nazwisko</Th>
          <Th>Adres Email</Th>
          <Th>Telefon</Th>
          <Th>Data rejestracji</Th>
          <Th/>
        </tr>
      </thead>
      <tbody>
        <tr>
          <Td>Jan</Td>
          <Td>Kowalski</Td>
          <Td>jan.kowalski@example.com</Td>
          <Td>670-123-853</Td>
          <Td>2022-01-01</Td>
          <Td className="td-actions">
            <a href="#" className="btn btn-sm btn-info">
              Zobacz
            </a>
          </Td>
        </tr>    
      </tbody>
    </TableWrapper>
    <div>
      <h1>GraphQL Data</h1>
      <ul>
        {data.books.map((item: { id: string; title: string }) => (
          <li key={item.id}>{item.title}</li>
        ))}
      </ul>
    </div>
  </DefaultLayout>
}