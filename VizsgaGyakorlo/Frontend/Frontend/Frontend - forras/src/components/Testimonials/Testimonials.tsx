/* ITT DOLGOZZON A FRONTENDES FELADATRÉSZBEN! */
import styles from "./Testimonials.module.css";
import left from "../../assets/icons/left.svg";
import right from "../../assets/icons/right.svg";
import { useEffect, useState } from "react";

export type TestimonialType = {
  name: string;
  age: number;
  location: string;
  testimonial: string;
  image: string;
};

const Testimonials = () => {
  const [testimonials, setTestimonials] = useState<TestimonialType[]>([]);
  const [currentIndex, setCurrentIndex] = useState<number>(0);

  useEffect(() => {
    fetch("/testimonials.json")
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        setTestimonials(data.testimonials);
      });
  }, []);

  const increaseIndex = () => {
    let num = currentIndex + 1;
    if (num + 1 === testimonials.length) {
      num = 0;
    }
    setCurrentIndex(num);
  };
  const decreaseIndex = () => {
    let num = currentIndex - 1;
    if (num < 0) {
      num = testimonials.length - 1;
    }
    setCurrentIndex(num);
  };

  return (
    <section className={styles.testimonials}>
      {testimonials.length > 0 && (
        <div className="testimonialCard">
          <div>
            <button onClick={decreaseIndex}>
              <img alt="Balra mutató nyíl" src={left} />
            </button>
            <div>
              <img alt="Profilkép" src={testimonials[currentIndex].image} />
              <div>
                <h3>
                  {testimonials[currentIndex].name} (
                  {testimonials[currentIndex].age})
                </h3>
                <h4>{testimonials[currentIndex].location}</h4>
              </div>
              <p>{testimonials[currentIndex].testimonial}</p>
              <a href="#">ÉN SEM HAGYOM KI!</a>
            </div>
            <button onClick={increaseIndex}>
              <img alt="Jobbra muató nyíl" src={right} />
            </button>
          </div>
        </div>
      )}
    </section>
  );
};

export default Testimonials;
