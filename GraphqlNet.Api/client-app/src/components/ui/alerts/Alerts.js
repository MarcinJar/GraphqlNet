import AlertDanger from "./alertDanger/AlertDanger";
import AlertSuccess from "./alertSuccess/AlertSuccess";

export default function Alerts({showDangerAlert, showSuccessAlert, handleSuccessOnClick, handleDangerOnCLick}) {
  return (
    <div className="alert-section">
      {
        showSuccessAlert && <AlertSuccess 
          handelOnClick={handleSuccessOnClick}
          message="Zadanie wykonano pomyślnie."/>
      }
      {
        showDangerAlert && <AlertDanger 
          handelOnClick={handleDangerOnCLick}
          message="Nie udało się wykonać zadania."/>
      }
    </div>
  )
}