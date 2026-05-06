//1-1 rublika felépítése az oldalon:
import React from 'react'
import moment from 'moment'
const Article = ({ title, snippet, date, length }) => {
//Megfelelő adatok hivatkozása és elrendezése:
  return (
    <article className='post'>
      <h2>{title}</h2>
      <div className='post-info'>
        <span>{moment(date).format('dddd Do, YYYY')}</span>
        <span>{length} percnyi olvasás</span>
      </div>
      <p>{snippet}</p>
    </article>
  )
}
//"Article"-ként hivatkozhassunk rá:
export default Article
