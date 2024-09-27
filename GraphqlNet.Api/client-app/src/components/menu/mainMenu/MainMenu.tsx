import Modal from "@/components/ui/modal/Modal";
import MainMenuItem from "./mainMenuItem/MainMenuItem";
import Subscription from "@/components/ui/subscription/Subscription";

export default function MainMenu({ className }: { className?: string }) {
  return <>
    <ul className={className}>
      <MainMenuItem url="/books">Panel głowny</MainMenuItem>
      <MainMenuItem url="/list">Kalendarz</MainMenuItem>
      <MainMenuItem url="/list">Tabela</MainMenuItem> 
      <MainMenuItem url="/list">Galeria</MainMenuItem>
      <MainMenuItem url="/list">Regulamin</MainMenuItem>
      <MainMenuItem url="/list">FAQ</MainMenuItem>
      <MainMenuItem url="/list">Kontakt</MainMenuItem>
    </ul>

    <Modal buttonTitle="Usługi dodatkowe" 
      title="Wybierz pakiet usług dodatkowych, który Ci odpowiada">
        <Subscription/>
    </Modal>
  </>
}