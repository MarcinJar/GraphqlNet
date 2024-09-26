export default function Footer({className}) {
  return (
    <footer className="mt-5">
      <small className={`text-sm md:text-xs text-blue-500 ` + className}>
        Tailwind CSS. Projektowanie <br/> 
        stron WWW i podejście <br/> 
        utility-first <br/>
        © {new Date().getFullYear()}
      </small>
    </footer>
  )
}