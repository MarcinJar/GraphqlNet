import Link from "next/link";
import Input from "../Input";

export default function RegisterForm() {
  return <form className="overflow-hidden bg-white rounded-lg shadow-xl">
    <div className="px-10 pt-8 pb-6 text-center">
      <h1 className="text-xl font-bold">
        Zarejstruj się
      </h1>
      <h2 className="text-xl">
        w panelu <strong>administracyjnym</strong>
      </h2>
      <div className="separator-horizontal"/>
      <div className="flex flex-col space-y-4 text-left">
        <Input type="email" label="E-mail"/>
        <Input type="email_repete" label="Powtórz adress e-mail"/>

        <Input type="password" label="Hasło"/>
        <Input type="password" label="Powtórz hasło"/>
      </div>
    </div>
    <footer className="flex items-center justify-center space-x-2 px-10 py-4 bg-gray-100 border-t border-gray-200">
      <Link href="/auth/login" className="btn btn-success">
        Zarejstruj się
      </Link>
      <Link href="/auth/login" className="btn btin-link">
        Masz już konto?
      </Link>
    </footer>
  </form>
}