import TimesCircleIcon from "../../icon/TimesCircleIcon";

export default function AlertDanger({handelOnClick, message = ''}) {
  return (
    <div className="alert alert-danger" onClick={handelOnClick}>
      <h6 className="alert-title">
        <TimesCircleIcon/>
        <span className="ml-1">
          Błąd!
        </span>
      </h6>
      <p>{message}</p>
    </div>
  )
}