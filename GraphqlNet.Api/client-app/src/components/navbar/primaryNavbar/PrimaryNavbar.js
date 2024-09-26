import Logo from "@/components/logo/Logo"
import MainMenu from "@/components/menu/mainMenu/MainMenu"
import Footer from "@/components/ui/footer/Footer"
import MenuIcon from "@/components/ui/icon/MenuIcon"
import { useState } from "react"

export default function PrimaryNavbar({className}) {
  const [isVisible, setIsVisible] = useState(false)

  function handleOnClick() {
    setIsVisible(!isVisible)
  }

  return (
    <div className="flex items-center justify-between text-blue-200 bg-blue-900 border-b 
      border-blue-700 shadow z-30 p-4 md:flex-shrink-0 md:w-56 md:py-0 md:px-8 md:justify-start">
        <Logo/>

        <div className="flex justify-end relative w-3/4 md:hidden">
          <MenuIcon onClick={handleOnClick}/>
          <div className={`absolute top-8 right-0 z-50 text-center ` + (!isVisible && 'hidden')}>
            <div className="bg-blue-800 p-5 rounded shadow-xl border border-blue-700 font-normal">
              <MainMenu/>
              <Footer/>
            </div>
          </div>
        </div>
    </div>
  )
}