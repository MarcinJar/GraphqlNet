
interface StartLayoutProps {
  children: React.ReactNode;
}

export default function StartLayout({ children }: Readonly<StartLayoutProps>) {

  return (
    <div className="flex flex-col h-screen">
      <div className="bg-green-500 h-1/3">
      </div>
      <div className="bg-blue-100 h-1/3">
        {children}
      </div>
      <div className="bg-green-500 h-1/3">
      </div>
    </div>
  )
}