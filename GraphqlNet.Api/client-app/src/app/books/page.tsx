import DefaultLayout from "@/components/layout/DefaultLayout";
import TableWrapper from "@/components/ui/table/tableWrapper/TableWrapper";
import Td from "@/components/ui/table/td/Td";
import Th from "@/components/ui/table/th/Th";

export default function Books() {
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
  </DefaultLayout>
}