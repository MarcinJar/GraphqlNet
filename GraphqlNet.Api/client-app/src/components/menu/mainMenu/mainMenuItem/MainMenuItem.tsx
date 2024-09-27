import Link from "next/link";

interface MainMenuItemProps {
  url: string,
  children: React.ReactNode,
}

export default function MainMenuItem({url, children}: MainMenuItemProps) {
  return <>
    <li className="pb-2">
      <Link href={url} className="p-1 text-blue-400 hover:text-blue-100 focus:*:text-blue-100">
        {children}
      </Link>
    </li>
  </>
}