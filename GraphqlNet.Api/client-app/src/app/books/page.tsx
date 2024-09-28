'use client'
import DefaultLayout from "@/components/layout/DefaultLayout";
import TableWrapper from "@/components/ui/table/tableWrapper/TableWrapper";
import Td from "@/components/ui/table/td/Td";
import Th from "@/components/ui/table/th/Th";
import { GetBooksDocument, GetBooksQuery } from "@/generated/graphql";
import { useQuery } from '@apollo/client';

export default function Books() {
  const { loading, error, data } = useQuery<GetBooksQuery>(GetBooksDocument);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

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
        {data?.books.map((item: { id: string; title: string }) => (
          <li key={item.id}>{item.title}</li>
        ))}
      </ul>
    </div>
  </DefaultLayout>
}