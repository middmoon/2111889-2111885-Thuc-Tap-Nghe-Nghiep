import Footer from "../component/footer";
import { Header } from "../component/header";

const withLayout = (WrappedComponent) => {
  return (props) => (
    <>
      <Header />
      <main className="min-h-screen">
        <WrappedComponent {...props} />
      </main>
      <Footer />
    </>
  );
};

export default withLayout;
