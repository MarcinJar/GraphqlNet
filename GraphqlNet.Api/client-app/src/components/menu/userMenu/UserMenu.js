import Link from "next/link"
import { useState } from "react"

export default function UserMenu() {
  const [isVisible, setIsVisible] = useState(false)

  function handleOnClick() {
    setIsVisible(!isVisible)
  }

  return (
    <>
      <div className="relative" onClick={handleOnClick}>
        <strong>Marcin </strong>
        <spn className="hidden md:inline">
          Jarmułowski
        </spn>
        <div className={`absolute top-8 right-0 bg-white p-5 rounded shadow-xl border 
        border-gray-100 font-normal ` + (!isVisible && 'hidden')}>
          <ul>
            <li className="pb-2">
              <a className="p-1 text-gray-500 hover:text-black focus:text-black">
                Ustawienia
              </a>
            </li>
            <div className="separator-horizontal my-1 border-b"/>
            <li>
              <Link href="/auth/login" className="p-1 font-bold text-gray-500 
              hover:text-red-600 focus:text-red-600">
                Wyloguj się
              </Link>
            </li>
          </ul>
        </div>
      </div>
    </>
  )
}