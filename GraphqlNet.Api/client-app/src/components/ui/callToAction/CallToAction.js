import Link from "next/link";
import CheckIcon from "../icon/CheckIcon";

export default function CallToAction({title = '', subTitle = '', call = '', url = ''}) {
  return (
    <div className="bg-gradient-to-r from-blue-100 to-blue-200 block shadow rounded-lg">
      <div className="group block xl:flex justify-between items-center p-8">
        <div className="max-w-1/2"> 
          {title && 
          <h2 className="font-semibold text-xl xl:text-2xl pr-0 lg:pr-5 text-blue-900 flex justify-start items-center">
            {title}
          </h2>}
          {subTitle && 
          <h3 className="font-bold pr-0 lg:pr-5 text-blue-500 flex justify-start items-center">
            {subTitle}
          </h3>}
        </div>
        <div className="mt-5 xl:mt-0 transition group-hover:transform group-hover:rotate-6">
          <Link href={url} className="btn btn-primary self-stretch">
            <CheckIcon/>
            <span className="ml-3">{call}</span>
          </Link>
        </div>
      </div>
    </div>
  )
}