import Card from "@/components/card/Card";
import { useEffect, useState } from "react";
import UserIcon from "../icon/UserIcon";
import BookIcon from "../icon/BookIcon";
import OfficeIcon from "../icon/OfficeIcon";
import CommentIcon from "../icon/CommentIcon";

export default function AppStatus() {
  const [newUsersCount, setNewUsersCount] = useState(0);
  const [newArticlesCount, setNewArticlesCount] = useState(0);
  const [newCustomersCount, setNewCustomersCount] = useState(0);
  const [newCommentsCount, setNewCommentsCount] = useState(0);

  useEffect(() => {
    setNewUsersCount(Math.floor(Math.random() * 15));
    setNewArticlesCount(Math.floor(Math.random() * 15));
    setNewCustomersCount(Math.floor(Math.random() * 15));
    setNewCommentsCount(Math.floor(Math.random() * 15));
  }, []);

  return <>
    <Card className="bg-gradient-to-r from-green-600 to-green-700 p-6">
      <h6 className="text-green-100 flex justify-start">
        <UserIcon/>
        <span className="ml-1">
          Nowi użytkownicy
        </span>
      </h6>
      <p className="text-white text-5xl">
        {newUsersCount}
      </p>
    </Card>
    <Card className="bg-gradient-to-r from-red-600 to-red-700 p-6">
      <h6 className="text-green-100 flex justify-start">
        <BookIcon/>
        <span className="ml-1">
          Nowe artykuły
        </span>
      </h6>
      <p className="text-white text-5xl">
        {newArticlesCount}
      </p>
    </Card>
    <Card className="bg-gradient-to-r from-blue-600 to-blue-700 p-6">
      <h6 className="text-green-100 flex justify-start">
        <OfficeIcon/>
        <span className="ml-1">
          Nowi klienci
        </span>
      </h6>
      <p className="text-white text-5xl">
        {newCustomersCount}
      </p>
    </Card>
    <Card className="bg-gradient-to-r from-yellow-600 to-yellow-700 p-6">
      <h6 className="text-green-100 flex justify-start">
        <CommentIcon/>
        <span className="ml-1">
          Nowe komentarze
        </span>
      </h6>
      <p className="text-white text-5xl">
        {newCommentsCount}
      </p>
    </Card>
  </>
}