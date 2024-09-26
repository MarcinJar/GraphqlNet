import Link from "next/link";
import Input from "../Input";
import Checkbox from "../Checkbox";

export default function LoginForm() {
  return <form className="overflow-hidden bg-white rounded-lg shadow-xl">
    <div className="px-10 pt-8 pb-6 text-center">
      <h1 className="text-xl font-bold">
        Zaloguj się
      </h1>
      <h2 className="text-xl">
        w panelu <strong>administracyjnym</strong>
      </h2>
      <div className="separator-horizontal"/>
      <div className="flex flex-col space-y-4 text-left">
        <Input label="Login"/>
        <Input label="Hasło" type="password"/>
        <Checkbox label="Zapamiętaj mnie"/>
      </div>
    </div>
    <footer className="flex items-center justify-center space-x-2 px-10 py-4 bg-gray-100 border-t border-gray-200">
      <Link href="/admin" className="btn btn-primary">
        Zaloguj się
      </Link>
      <Link href="/auth/register" className="btn btin-link">
        Nowe konto
      </Link>
    </footer>
  </form>
}