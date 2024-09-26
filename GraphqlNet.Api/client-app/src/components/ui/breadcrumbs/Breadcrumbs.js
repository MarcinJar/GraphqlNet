import HomeIcon from "../icon/HomeIcon";
import BreadcrumbItem from "./breadcrumbItem/BreadcrumbItem";

export default function Breadcrumbs({title = ''}) {
  return (
    <div className="bg-blue-100 shadow rounded mb-4 p-4 flex justify-start items-center truncate">
      <BreadcrumbItem url="/">
        <HomeIcon/>
      </BreadcrumbItem>
      <BreadcrumbItem url="/books">
        <span className="ml-2">Main page</span>
      </BreadcrumbItem>
      <BreadcrumbItem isCurrent={true}>
        {title}
      </BreadcrumbItem>
    </div>
  )
}