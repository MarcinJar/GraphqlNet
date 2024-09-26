interface ThPros {
  children?: React.ReactNode;
}

export default function Th({children}: ThPros) {
  return (
    <th className="bg-blue-100 text-left text-blue-800 p-3 shadow">
      {children}
    </th>
  )
}