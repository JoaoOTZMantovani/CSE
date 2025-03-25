const products = [
    { id: "177c382b-9211-4f8d-a726-a9386197c558", name: "Banho de Ervas", materialValue: 2.35, productionValue: 0.50, profitValue: 1.00 },
    { id: "4e0d8ac9-e17c-4c0c-a4a2-25ae8b0cc584", name: "Banho de Ervas Premium", materialValue: 6.85, productionValue: 1.40, profitValue: 2.80 },
    { id: "8d0a5c19-3f47-4e5a-b87f-63cfbbbdbf24", name: "Frasco de Alfazema Rustico", materialValue: 13.90, productionValue: 2.80, profitValue: 5.60 },
];

document.addEventListener("DOMContentLoaded", function () {

    let orderDetailsSection = document.querySelector("#OrderDetaisSection");

    orderDetailsSection.addEventListener("change", handlerOrderChange);
    orderDetailsSection.addEventListener("input", handlerOrderChange);
});

function handlerOrderChange(event) {
    updatePrice(event);

    updateSummaryPrice();
}

function updateSummaryPrice() {
    let materialTotal = 0, productionTotal = 0, profitTotal = 0, finalAmount = 0;

    document.querySelectorAll('[data-order-item]').forEach((itemOrder, index) => {
        let selectProduct = itemOrder.querySelector("[data-ordem-item-product]");
        let quantityInput = itemOrder.querySelector("[data-ordem-item-product-quantity]");

        let selectedOption = selectProduct.options[selectProduct.selectedIndex].text;
        let quantity = parseInt(quantityInput.value) || 0;
        let product = products.find(p => p.name === selectedOption);

        if (product && quantity > 0) {
            materialTotal += product.materialValue * quantity;

            productionTotal += product.productionValue * quantity;

            profitTotal += product.profitValue * quantity;

            finalAmount += (product.materialValue + product.productionValue + product.profitValue) * quantity;
        }
    });

    document.getElementById("orderMaterialValue").value = materialTotal.toFixed(2);

    document.getElementById("orderProductionValue").value = productionTotal.toFixed(2);

    document.getElementById("orderProfitValue").value = profitTotal.toFixed(2);

    document.getElementById("orderFinalValue").value = finalAmount.toFixed(2);
}

function updatePrice(event) {
    let itemOrder = event.target.closest("[data-order-item]");

    if (!itemOrder) {
        return;
    }

    let selectProduct = itemOrder.querySelector("[data-ordem-item-product]");
    let quantityInput = itemOrder.querySelector("[data-ordem-item-product-quantity]");
    let amountInput = itemOrder.querySelector("[data-ordem-item-product-amount]");

    let selectedOption = selectProduct.options[selectProduct.selectedIndex].text;
    let quantity = parseInt(quantityInput.value) || 0;
    let product = products.find(p => p.name === selectedOption);

    if (product && quantity > 0) {
        let finalPrice = (product.materialValue + product.productionValue + product.profitValue) * quantity;

        amountInput.value = finalPrice.toFixed(2);
    }
    else {
        amountInput.value = "";
    }
}

function addOrderItem() {

    let newOrderItemHrml = `
        <div class="row row-order-iten-responsive mb-3" data-order-item>
            <div class="col-4">
                <select class="form-select text-center" data-ordem-item-product>
                    <option selected>Selecionar produto</option>
                    ${products.map(p => `<option value="${p.id}">${p.name}</option>`).join("")}
                </select>
            </div>
             <div class="col-2">
                <input class="form-control text-center" type="number" placeholder="Qtd."
                    data-ordem-item-product-quantity>
            </div>
            <div class="col-2">
                <input class="form-control text-center" type="number" placeholder="00,00" readonly
                    data-ordem-item-product-amount>
            </div>
            <div class="col-3">
                <input class="form-control text-center" type="text" placeholder="Observação"
                    data-ordem-item-product-observation>
            </div>
            <div class="col-1">
                <button type="button" class="btn btn-danger" onclick="removeOrderItem(this)">
                    <i class="bi bi-trash"></i></button>
            </div>
        </div>
    `;

    document.querySelector("#OrderDetaisSection .container-order-itens-responsive").insertAdjacentHTML("beforeend", newOrderItemHrml);
}


function removeOrderItem(button) {
    let itemOrder = button.closest("[data-order-item]");

    if (itemOrder) {
        itemOrder.remove();
    }

    updateSummaryPrice();
}

function recycleOrder() {
    let orderItems = document.querySelectorAll('[data-order-item]');

    if (orderItems == 1) {
        return;
    }

    orderItems.forEach((item, index) => {
        if (index == 0) {
            item.querySelector("[data-ordem-item-product]").selectedIndex = 0;

            item.querySelector("[data-ordem-item-product]").selectedIndex = 0;

            item.querySelector("[data-ordem-item-product-quantity]").value = "";

            item.querySelector("[data-ordem-item-product-amount]").value = "";

            item.querySelector("[data-ordem-item-product-observation]").value = "";
        }
        else {
            item.remove();
        }
    });

    updateSummaryPrice();
}