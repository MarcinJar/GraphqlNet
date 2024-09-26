import Link from "next/link";

export default function MainMenuItem({url, children}) {
  return <>
    <li className="pb-2">
      <Link href={url} className="p-1 text-blue-400 hover:text-blue-100 focus:*:text-blue-100">
        {children}
      </Link>
    </li>
  </>
}