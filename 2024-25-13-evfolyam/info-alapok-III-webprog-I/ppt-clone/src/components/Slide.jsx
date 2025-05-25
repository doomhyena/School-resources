function Slide({ slide }) {
  if (!slide) return <div className="text-red-500">Nincs slide betöltve 😢</div>;

  return (
    <div>
      <h1>{slide.title}</h1>
      <p>{slide.content}</p>
      {slide.subtitle && <h2 className="text-gray-500">{slide.subtitle}</h2>}
    </div>
  );
}


export default Slide;
