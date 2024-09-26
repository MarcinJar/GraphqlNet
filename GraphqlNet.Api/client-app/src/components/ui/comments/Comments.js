import Card from "@/components/card/Card";
import Comment from "./Comment";


export default function Comments() {
  return (
    <Card title="Najświerzsze komentarze">
      <ul className="grid grid-cols-1 gap-2">
        <Comment title="komentarz przykładowy" date="">
          Świetna obsługa! Wszystko tak, jak być należy.
        </Comment>
        <Comment title="Super" date="">
          Jestem zadowolony. Na pewno wrócę skorzystać z Państwa usług.
        </Comment>
        <Comment title="Przykro mi" date="">
          Wykonanie usługi pozostawia wiele do życzenia.
        </Comment>
        <Comment title="Świetny produkt" date="">
          Polecam i na pewno jeszcze wrócę!
        </Comment>
      </ul>
    </Card>
  )
}