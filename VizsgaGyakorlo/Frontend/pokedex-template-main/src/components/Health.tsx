const fullHeart = <i className="fa-solid fa-heart"></i>;
const crackedHeart = <i className="fa-solid fa-heart-crack"></i>;
const emptyHeart = <i className="fa-regular fa-heart"></i>;

const Health = (props: { hp: number }) => {
  const chooseHeart = (id: number) => {
    if (id < Math.floor(props.hp)) return fullHeart;
    if (id < props.hp) return crackedHeart;
    return emptyHeart;
  };

  return (
    <div className="health">{[...Array(5)].map((_, i) => chooseHeart(i))}</div>
  );
};

export default Health;
