import StartLayout from "@/components/layout/StartLayout";
import Link from "next/link";

export default function Home() {
  return (
    <StartLayout>
      <div className="grid grid-cols-1 gap-4 justify-center items-center h-full">
        <h1 className="flex justify-center items-end h-full">
          Welcome to Next.js!
        </h1>
        <div className="flex justify-center space-x-2 items-start h-full">
          <Link href="/auth/login" className="btn btn-success">
            Zaloguj się
          </Link>
          <Link href="/auth/register" className="btn btn-primary">
            Zarejstruj
          </Link>
        </div>
      </div>
    </StartLayout>
  );
}
