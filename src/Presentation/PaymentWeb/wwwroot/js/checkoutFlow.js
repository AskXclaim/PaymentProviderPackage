// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// import "https://checkout-web-components.checkout.com/index.js"
// 
const mountFlow = async (publicKey,paymentSession) => {
        console.log("Checkout Web Page");
        const checkout = await CheckoutWebComponents({
            publicKey: `${publicKey}`,
            environment: "sandbox",
            locale: "en",
            paymentSession: paymentSession,
            translations: {
                en: {"pay_button.pay": "Register Card"},
            },
            onReady: () => {
                console.log("onReady");
            },
            onPaymentCompleted: (_component, paymentResponse) => {
                console.log("Create Payment with PaymentId: ", paymentResponse.id);
            },
            onChange: (component) => {
                console.log(
                    `onChange() -> isValid: "${component.isValid()}" for "${
                        component.type
                    }"`,
                );
            },
            onError: (component, error) => {
                console.log("onError", error, "Component", component.type);
            },
        });

        const flowComponent = checkout.create("flow");
        const flowElement = document.getElementById('flow-container');

        flowComponent.mount(flowElement);
}

export default mountFlow;
