import Card from "@/components/card/Card";
import ArticleFooter from "./articleFooter/ArticleFooter";
import { useState } from "react";
import Alerts from "../alerts/Alerts";

export default function Article({title, author, date, children}) {
  const [showDangerAlert, setShowDangerAlert] = useState(false)
  const [showSuccessAlert, setShowSuccessAlert] = useState(false)
  const [randomViews] = useState(Math.floor(Math.random() * 100))
  const [randomsharing] = useState(Math.floor(Math.random() * 100))

  function handleDangerOnClick() {
    setShowDangerAlert(true)
    setTimeout(() => setShowDangerAlert(false), 5000)
  }

  function handleSuccessOnClick() {
    setShowSuccessAlert(true)
    setTimeout(() => setShowSuccessAlert(false), 5000)
  }

  return (
    <Card className="article">
      <h1 className="article-title">
        {title}
      </h1>

      <section className="article-data">
        <div>
          {author}, {date}
        </div>
        <div className="inline-flex space-x-2 mt-5">
          <a href="#" className="btn btn-danger" onClick={handleDangerOnClick}>
            Udostępnij artykuł
          </a>
          <a href="#" className="btn btn-success" onClick={handleSuccessOnClick}>
            Zapisz na później
          </a>
        </div>
      </section>

      <article className="article-content">
        {children}
      </article>

      <footer className="article-footer">
        <ArticleFooter
          views={randomViews}
          words={452}
          chars={6378}
          sharing={randomsharing}/>
      </footer>

      <Alerts 
        showSuccessAlert={showSuccessAlert}
        showDangerAlert={showDangerAlert}
        handleSuccessOnClick={handleSuccessOnClick}
        handleDangerOnClick={handleDangerOnClick}/>
    </Card>
  )
}