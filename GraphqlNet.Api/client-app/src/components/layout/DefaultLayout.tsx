import MainMenu from "@/components/menu/mainMenu/MainMenu";
import PrimaryNavbar from "@/components/navbar/primaryNavbar/PrimaryNavbar";
import SecondaryNavbar from "@/components/navbar/secondaryNavbar/SecondaryNavbar";
import Breadcrumbs from "@/components/ui/breadcrumbs/Breadcrumbs";
import Footer from "@/components/ui/footer/Footer";

interface DefaultLayoutProps {
  children: React.ReactNode;
  title?: string;
}


export default function DefaultLayout({ children, title = '' }: DefaultLayoutProps) {
  return (
    <div className="flex flex-col h-screen">
      <div className="md:flex">
         <PrimaryNavbar />
         <SecondaryNavbar/>
      </div>
      <div className="flex flex-grow overflow-hidden">
        <div className="hidden md:flex items-start justify-between px-8 py-8 bg-blue-800
          text-blue-100 md:flex-shrink-0 md:w-56 md:justify-start">
          <div className="relative">
             <MainMenu/>
             <Footer className={undefined}/>
          </div>
        </div>
        <div className="w-full overflow-hidden overflow-y-auto p-0 bg-gray-100 py-0 md:py-8">
          <div className="p-4 md:py-0 md:px-12">
             <Breadcrumbs title={title} />

            <section>
              {children}
            </section>
          </div>
        </div>
      </div>
    </div>
  )
}