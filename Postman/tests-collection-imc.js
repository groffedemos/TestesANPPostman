var peso = JSON.parse(pm.collectionVariables.get("peso"));
var altura = JSON.parse(pm.collectionVariables.get("altura"));
var imc = JSON.parse(pm.collectionVariables.get("imc"));

if (peso > 0 && altura > 0) {
    
    pm.test("Retorno OK", function() {
        pm.response.to.be.ok;
        pm.response.to.json;
        pm.response.to.be.withBody;
    });

    var result = pm.response.json();

    pm.test("Checar Peso", function() {
        pm.expect(result.peso).to.eql(peso);
    });

    pm.test("Checar Altura", function() {
        pm.expect(result.altura).to.eql(altura);
    });

    pm.test("Checar IMC - Índice de Massa Corpórea", function() {
        pm.expect(result.imc).to.eql(
            pm.collectionVariables.get("imc")
        );
    });

    pm.test("Checar Situação Peso", function() {
        pm.expect(result.situacao).to.eql(
            pm.collectionVariables.get("situacao")
        );
    });

}
else {

    pm.test("Retorno Inválido", function() {
        pm.response.to.be.badRequest;
    });
    
}