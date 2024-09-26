import ButtonPrimary from "@/components/button/ButtonPrimary";
import Card from "@/components/card/Card";
import CheckIcon from "../icon/CheckIcon";

export default function SubscriptionItem({title, children}) {
  return <div>
    <Card title={title} className="group transition hover:shadow-2xl hover:scale-110 
    hover:bg-blue-100 font-semibold hover:font-bold">
        <div className="h-separator"/>
        <Card className="mb-4 font-normal">
          {children}
        </Card>
        <ButtonPrimary className="w-full flex justify-center">
          <CheckIcon/>
          <span className="ml-2">
            Wybierz
          </span>
        </ButtonPrimary>
    </Card>
  </div>
}